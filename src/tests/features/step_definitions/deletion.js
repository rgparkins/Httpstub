const request = require('request');
const expect = require('chai').expect;

var systemUnderTestHost = process.env.SERVICE_UNDER_TEST_HOSTNAME || 'http://localhost:8081';

module.exports = function () {
    var self = this;

    this.When(/^removing all data$/, function (callback) {
        var url = systemUnderTestHost + "/";

        request({
            url: url,
            method: "DELETE",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);

            callback();
        });
    });

    this.When(/^removing data on ([^"]*)$/, function (path, callback) {
        var url = systemUnderTestHost + "/" + path;
        
        request({
            url: url,
            method: "DELETE",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);

            callback();
        });
    });

    this.When(/^removing by ([^"]*)$/, function (path, callback) {
        var url = systemUnderTestHost + "/" + path;

        request({
            url: url,
            method: "DELETE",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);

            callback();
        });
    });
}