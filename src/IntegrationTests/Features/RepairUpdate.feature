Feature: Receiving repair updates

Scenario: Customer receives an update when the repair is complete
    Given that a customer is registered with a valid email address
    And the customer has submitted a vehicle for repair
    When the repair of the vehicle is completed
    Then an update should be sent to the customer's email address
    Then the update should contain the following information
    | Subject          | Message                                                |
    | Repair Completed | Your repair is complete. You can pick up your vehicle. |