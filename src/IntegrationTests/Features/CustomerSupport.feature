Feature: Customer Support Data Repository

Scenario: Get all rejections
  Given I have a customer support data repository
  When I request all rejections
  Then I should receive a list of rejections