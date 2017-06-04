Feature: Using the service as a stub

  Scenario Outline: Posting and Retrieving existing data
  Given the service has <data> on <path>
  Then fetching the data from <path> will return <status> and <content>

  Examples:
     | data                       | path         | status | content                    |
     | { text : 'hello world' }   | recons/guid  | 200    | { text : 'hello world' }   |
     | { text : 'hello world 2' } | recons/guid2 | 200    | { text : 'hello world 2' } |

  Scenario Outline: Retrieving data that does not exist in the stub
  Given the service has <data> on <path>
  When fetching the data from <invalidPath> a 404 is returned

   Examples:
      | data                       | path         | invalidPath  |
      | { text : 'hello world' }   | recons/guid  | recons/a     |
      | { text : 'hello world 2' } | recons/guid2 | adsdsds      |

  Scenario Outline: Existing data is removed from the stub
  Given the service has <data> on <path>
  When removing data from <path>
  Then a 404 is returned from <path>

  Examples:
     | data                       | path         |
     | { text : 'hello world' }   | recons/guid  |

  Scenario Outline: Clearing the stub
  Given the service has <data> on <path>
  When removing all data
  Then a 404 is returned from <path>

  Examples:
     | data                       | path         |
     | { text : 'hello world' }   | recons/guid  |