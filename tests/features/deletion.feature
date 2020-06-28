Feature: Deleting the cache data

  Scenario Outline: Clearing the stub
  Given the service has <data> on <path>
  When removing all data
  Then a 404 is returned from <path>

  Examples:
     | data                       | path         |
     | { text : 'hello world' }   | recons/guid  |

  Scenario Outline: Deleting by a root
  Given the service has <data> on <path>
  And the service has <data2> on <path2>
  And the service has <data3> on <path3>
  When removing data on recons/
  Then a 404 is returned from <path>
  And a 404 is returned from <path2>
  And a 200 is returned from <path3> with <data3>

  Examples:
     | data                       | path           | data2                      | path2         | data3    | path3  |
     | { text : 'hello world' }   | recons/data/1  | { text : 'hello world 2' } | recons/data/2 | { a: 1 } | test/1 |