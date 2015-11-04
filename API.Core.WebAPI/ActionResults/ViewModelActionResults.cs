using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Newtonsoft.Json;

namespace API.Core.Rest.WebAPI.ActionResults
{

    public class ViewModelActionResult : IHttpActionResult
    {
        public Type DestinationType { get; }
        readonly object[] _domainSources;
        private readonly HttpRequestMessage _request;

        public ViewModelActionResult(Type destinationType, HttpRequestMessage request, params object[] domainSources)
        {
            _domainSources = domainSources;
            DestinationType = destinationType;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                var sourceQueue = new Queue(_domainSources);
                var initialSource = sourceQueue.Dequeue();
                Type sourceType = initialSource.GetType();

                var compositeViewModel = Mapper.Map(initialSource, sourceType, DestinationType);


                while (sourceQueue.Count > 0)
                {
                    var source = sourceQueue.Dequeue();
                    Mapper.Map(source, compositeViewModel, source.GetType(), DestinationType);
                }

                //  GlobalConfiguration.Configuration.Formatters
                var formatter = new JsonMediaTypeFormatter
                {
                    SerializerSettings =
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                };

                var response = new HttpResponseMessage()
                {
                    Content = new ObjectContent(compositeViewModel.GetType(), compositeViewModel, formatter,
                            new MediaTypeWithQualityHeaderValue("application/json")),
                    RequestMessage = _request
                };

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }
    }
}