Feature: Browserstack


Scenario: Snapshot of a responsive website
	Given A responsive website I have permission to test
	When I take a snapshot using a device
	Then It will match the expected snapshot