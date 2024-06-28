Feature: Search Book

Scenario: Search book with multiple results
    Given there are books named "Learning JavaScript Design Patterns" and "Designing Evolvable Web APIs with ASP.NET"
    And the user is on Book Store page
    When the user input book name "Design" or "design"
    Then all books match with input criteria will be displayed