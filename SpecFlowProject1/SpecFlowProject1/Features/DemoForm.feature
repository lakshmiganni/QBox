Feature:Validating Demo Form Fields

As a user 
I am able to register for a demo
	
	Background: 
	
	Given I navigated to the url
	When I click on See a Demo button


Scenario Outline: Verify to register for a demo without entering the mandatory fields
	
	Then I navigated to the Demo form Modal with title <demoPageTitle>
	When I select reCAPTCHA checkbox
	And I click on submit button
	Then I should see an error message for all the mandatory fields as <errorMessage> 

	Examples: 
	| errorMessage             | demoPageTitle |
	| "This field is required" | "See a demo"  |


Scenario Outline: Validating the company email address
	
	Then I navigated to the Demo form Modal with title <demoPageTitle>
	When I enter field Company Email Address as <emailAddress>
	And I enter field First Name as <firstName>
	And I enter field Last Name as <lastName>
	And I enter field Job Title as <jobTitile>
	And I enter field Industry as <Industry> 

	And I select reCAPTCHA checkbox
	And I click on submit button
	Then I should see company email error message as <emailErrorMessage> 

	Examples: 
	| demoPageTitle | emailErrorMessage                              | emailAddress		     | firstName   | lastName    | jobTitile | Industry  |
	| "See a demo"  | "Please enter a valid business email address." | "lakshmi@hotmail.com" | "T£5t_ T%*" | "T£5t_ T%*" | "73St!nG" | "Medical" |
 

Scenario: Verify no login is required to navigate to the application and request a demo
	
	Then I navigated to the Demo form Modal with title <demoPageTitle>

Scenario Outline: Verifying user is not able to sublit the demo request form with invalid email address
	
	Then I navigated to the Demo form Modal with title <demoPageTitle>
	When I enter field Company Email Address as <emailAddress>
	And I enter field First Name as <firstName>
	And I enter field Last Name as <lastName>
	And I enter field Job Title as <jobTitile>
	And I enter field Industry as <Industry> 

	And I select reCAPTCHA checkbox
	And I click on submit button
	Then I should see company email error message as <emailErrorMessage> 

	Examples: 
	| demoPageTitle | emailErrorMessage                              | emailAddress | firstName   | lastName    | jobTitile | Industry  |
	| "See a demo"  | "Please enter a valid business email address." | "test@" | "T£5t_ T%*" | "T£5t_ T%*" | "73St!nG" | "Medical" |



