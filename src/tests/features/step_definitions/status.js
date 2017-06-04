const request = require('request');
const expect = require('chai').expect;

var systemUnderTestHost = process.env.SERVICE_UNDER_TEST_HOSTNAME || 'http://localhost:8081';

module.exports = function () {
    var self = this;

    this.Given(/^the service has started$/, function (callback) {
        callback();
    });

    this.When(/^pinging the endpoint will return 200$/, function (callback) {
        var url = systemUnderTestHost + "/private/ping";

        request({
            url: url,
            method: "GET",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);

            callback();
        });
    });
}