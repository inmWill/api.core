using System.Web.Http;
using API.Core.Repository.Repositories;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class RefreshTokensController : ApiController
    {
    //    private IAuthRepository _authRepository;
        private readonly AuthRepository _repo = null;

        public RefreshTokensController()
        {
        //    _authRepository = authRepository;
            _repo = new AuthRepository();
        }

        [API.Core.Rest.WebAPI.Attributes.Authorize(Users = "Admin")]
        public IHttpActionResult Get()
        {
            return Ok(_repo.GetAllRefreshTokens());
        }

        [API.Core.Rest.WebAPI.Attributes.Authorize(Users = "Admin")]
        public IHttpActionResult Delete(string tokenId)
        {
            var result = _repo.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}