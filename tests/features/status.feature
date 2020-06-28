Feature: Health of service

  Scenario Outline: Pinging the service
  Given the service has started
  Then pinging the endpoint will return 200