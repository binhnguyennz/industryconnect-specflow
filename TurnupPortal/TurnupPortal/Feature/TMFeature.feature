Feature: TMFeature

As a TurnUp portal admin
I would like to create, edit and delete Time and Meterialrecords
so that i can manage Employee's time and materials successfully

@create
Scenario: 1 Create time and material record with valid data
    Given I logged into Turnup portal successfully
    When I navigate to Time and Material page
    When I created a new Time and Material record
    Then The record should be created successfully

@edit
Scenario Outline: 2 edit time and material record with valid data
    Given I logged into Turnup portal successfully
    When I navigate to Time and Material page
    When I edit '<Description>', '<Code>', '<Price>' on an existing time and material record
    Then The record should have the updated '<Description>', '<Code>', '<Price>'
    
    Examples:
    | Description         | Code   | Price |
    | Honda Insight 2019  | Car    | 25000 |
    | Macbook pro M1 2020 | Laptop | 2499  |
    | Iphone 13 Pro Max   | Phone  | 1300  | 

