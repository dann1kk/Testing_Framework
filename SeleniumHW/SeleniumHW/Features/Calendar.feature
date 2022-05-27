Feature: Calendar
	       A calendar which includes all working days, with possibilities to add working hours and absences.
 
 Background: 
 Given I logged in successfully
 And I am on my personal Advance Calendar page
@positive
Scenario: Add Working Hours
	When I click on today's day box
	And I click project field
	And I choose project 
	|  Project|
	|  test DG|
	And I click role field
	And I choose role
	|  Role|
	|  Associate QA Engineer|
	And I click approve button
	Then a pop up message of successfully added hours is displayed
	And the working hours are saved

@positive
Scenario: Change Working Hours
	When I click on working hours 
	And I increase working hours 
	|  Hours|
	|  7.6|
	And I click ok button
	Then a pop up message of successfully updated hours is displayed
	And new working hours are saved

@positive 
Scenario: Delete Working Hours
	When I click on delete button on my working hours
	And I click Yes button
	Then a pop up message of successfully deleted hours is displayed
	And working hours are deleted
    
@positive
Scenario: Select all days until current date
	When I click on select until current date
	Then all days until current are selected

@positive
Scenario: Select all month days 
	When I click on select all
	Then all month days are selected

@positive
Scenario: Add absence in the calendar
	When I click on today's day box
	And I click leaves 
	And I click type category
	And I choose type category
	| Type |
	|  Sick|
	And I click ok button
	Then a pop up message of successfully added absence is displayed
	And the absence is saved in calendar

@positive
Scenario: Change absence type
	When I click on absence box in the calendar
	And I click type category
	And I change type category
	| Type |
	|  Holiday|
	And I click ok button
	Then a pop up message of successfully updated absence is displayed
	And updated absence is saved

@positive
Scenario: Delete absence 
	When I click on delete button on absence 
	And I click Yes button
	Then a pop up message of successfully deleted absence is displayed
	And absence is deleted

 @positive
 Scenario: Display another month calendar
   When I click on month and year box
   And I click february button
   Then the calendar for february month is displayed

 @negative
 Scenario: Add working hours with no project
   When I click on today's day box
   And I click approve button
   Then a warning message is displayed

 @negative 
 Scenario: Add absence with end date in the past
   When I click on today's day box
	And I click leaves 
	And I click type category
	And I choose a new type category
	| Type |
	|  Sick|
	And I click end date field
	And I choose end date 
	| End Date |
	| 18/5/2022|
	And I click ok button
	Then a warning message is displayed