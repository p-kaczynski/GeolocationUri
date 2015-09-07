GeolocationUri
=============

## Purpose
This library provides parsing of [RFC 5870](https://tools.ietf.org/html/rfc5870)-compliant URIs, or creating them. 

## Usage
`GeolocationUri` provides `Parse` and `TryParse` methods that take a string. Parsed data is available through get-only properties that give access to longitude, lattitude, altitude, the coordinate system id, uncertainty value and other parameters that might be relevant for the given system.

The `ToString` method formats data from the properties into a compliant URI string.