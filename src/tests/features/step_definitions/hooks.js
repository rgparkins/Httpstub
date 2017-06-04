'use strict';

const apickli = require('apickli');

/**
 * @function
 *
 * Hooks can be used to prepare and clean
 * the environment before and after
 * each scenario is executed
 */
module.exports = function() {
    const SERVICE_UNDER_TEST_HOSTNAME = process.env.SERVICE_UNDER_TEST_HOSTNAME || 'localhost:8081'
    
    /**
     * To run something before every scenario,
     * use before hooks
     *
     * @param  {Function} callback a done callback from cucumber.js
     */
    this.Before(function() {

        
    });


    /**
     * To run something after every scenario,
     * use after hooks
     *
     * @param  {Function} callback a done callback from cucumber.js
     */
    this.After(function() {

        //don't forget to tell cucumber when your done
    });
}