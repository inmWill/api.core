Feature: AddSurvey
	In order to identify ocv violations
	As a dependent eligiblity auditor
	I need to create a new survey

@SurveyApp
Scenario: Add new survey
	Given I have selected a client
	And I have entered survey name
	When I complete entering more information
	Then the survey should persist to the database
