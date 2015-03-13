# DNNSiteGallery
Allows you to create a site gallery on your DNN website.

This started as a fork of [SiteGallery on CodePlex](https://dnnsitegallery.codeplex.com/)

Main View
=========
The main view allows you to display information about the sites in your gallery. It is templatable so you can format the HTML however you want for displaying sites. You have control over the number of columns and rows per page. Users that are logged in and have Edit permissions can submit their sites.

Add sites
---------
An individual user can submit and maintain multiple sites, so there is an option to select a site from a list or specify that you wish to add a new site. You must provide a URL, Title, and Description. The Owner and Owner URL fields are optional and can be used in the scenario where you would like to direct traffic to a URL that is different than the site URL.

Settings
--------
The first section controls the output for the main view. You can see there are [TOKENS] for all site fields. The second section defines thumbnail generation for the sites. By default it will use the WebBrowser control, but this does not work in some environments ( ie. Azure ). So you can specify a URL to a thumbnail generator service. There are a bunch of free and inexpensive ones listed behind the Options button. For example, Screenshot Machine provides a simple URL: http://api.screenshotmachine.com/?key=1234xx&size=X&format=JPG&cacheLimit=0&timeout=0&url=[URL] ( you get the key when you register and the [URL] item is a token that is substituted at run-time by the module ). You can specify the size and where to store the thumbnails. Refresh frequency is related to a scheduled job that runs in the background, validating the site is still active and generating a new screen shot. The retain history option allows you to retain ALL historic screenshots for a site - which you can view through the Edit UI above. The Site Validation allows you to provide a URL fragment which needs to exist on the site in order for it to be considered valid for the gallery. An example is "/js/dnn.js" which would verify that the site is running DNN ( but you could of course also require a customer to upload a specific file to their site and use this as a validation URL instead ). The instruction field allows you to provide information to explain to the user what is necessary for them to validate their site. The validation options are completely optional - if you simply want the module to verify that a site is active or not then you don't need to specify a Validation URL.
