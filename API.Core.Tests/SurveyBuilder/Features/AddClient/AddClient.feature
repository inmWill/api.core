Feature: Add Client
Allow users to create and store new clients
As long as the new clients have a name and email

Scenario: HappyPath
Given a user has entered information about a client
And she has provided a name and a email as required
When she completes entering more information
Then that client should be stored in the system


Scenario: Missing Required Data
Given a user has entered information about a client
And she has not provided the name and email
When she completes entering more information
Then that user will be notified about the missing data