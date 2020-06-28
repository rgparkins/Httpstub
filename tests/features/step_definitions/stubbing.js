const request = require('request');
const expect = require('chai').expect;

var systemUnderTestHost = process.env.SERVICE_UNDER_TEST_HOSTNAME || 'http://localhost:8081';

module.exports = function () {
    var self = this;

    this.Given(/^the service has ([^"]*) on ([^"]*)$/, function (data, path, callback) {
        var url = systemUnderTestHost + "/" + path;

        request({
            url: url,
            method: "POST",
            json: data,
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);

            callback();
        });
    });

    this.When(/^fetching the data from ([^"]*) will return ([^"]*) and ([^"]*)$/, function (path, status, content, callback) {
        var url = systemUnderTestHost + "/" + path;

        request({
            url: url,
            method: "GET",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(parseInt(status));
            expect(content).to.equal(body);

            callback();
        });
    });

    this.When(/^fetching the data from ([^"]*) a 404 is returned$/, function (invalidPath, callback) {
        var url = systemUnderTestHost + "/" + invalidPath;

        request({
            url: url,
            method: "GET",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(404);

            callback();
        });
    });

    this.When(/^removing data from ([^"]*)$/, function (path, callback) {
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

    this.Then(/^a 404 is returned from ([^"]*)$/, function (path, callback) {
        var url = systemUnderTestHost + "/" + path;

        request({
            url: url,
            method: "GET",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(404);

            callback();
        });
    });

    this.Then(/^a 200 is returned from ([^"]*) with ([^"]*)$/, function (path, content, callback) {
        var url = systemUnderTestHost + "/" + path;

        request({
            url: url,
            method: "GET",
            timeout: 1000
        }, function (error, response, body) {
            if (error)
                throw error

            expect(response.statusCode).to.equal(200);
            expect(content).to.equal(body);

            callback();
        });
    });
}