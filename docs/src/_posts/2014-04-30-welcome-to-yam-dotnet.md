---
layout: post
title:  "Welcome to the YamNet Project"
date:   2014-04-30 06:00:00
categories: welcome
---

Welcome! YamNet is an unofficial, opinionated, Yammer REST API .NET (async) wrapper based on the the CodePlex [ContractMeow](http://yammercontractmeow.codeplex.com/) project. The goal is to provide a ready-to-use client library available via NuGet.

This project started due to the lack of an up-to-date Yammer REST API .NET wrapper. Most of the initial code was based on the excellent and comprehensive [ContractMeow](http://yammercontractmeow.codeplex.com/) project. Big thanks to [jmjc95](http://www.codeplex.com/site/users/view/jmjc95) and [tuongla](http://www.codeplex.com/site/users/view/tuongla).

The original use case was for the library to help retrieve Yammer data for server-side processing (e.g. analytics and administrative tasks). However, through the use of PCL classes, it can also be reused in mobile projects (via Xamarin.iOS and Xamarin.Android) and Silverlight projects.

At this stage, the project only covers the REST API methods and not the OAuth negotiation. The assumption is that the API 'access_token' has been retrieved to be used in instantiating the Client.

I hope you will find this project useful. Feedback and pull request(s) welcome :)