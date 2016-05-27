# ![openPDC](https://www.gridprotectionalliance.org/images/products/openPDC.png)

Open Source Phasor Data Concentrator

The [openPDC](https://www.gridprotectionalliance.org/products.asp#PDC) administered by the [Grid Protection Alliance](https://www.gridprotectionalliance.org/) (GPA) is a complete Phasor Data Concentrator software system designed to process streaming time-series data in real-time. Measured data gathered with GPS-time from many hundreds of input sources is time-sorted and provided to user defined actions as well as to custom outputs for archival.

# Overview

A phasor data concentrator is designed to receive streaming synchrophasor data from phasor measurement units (PMUs) installed on power transmission lines and align this data by GPS time-tag (i.e., it "concentrates" the data based on time). The output of a PDC is a time-synchronized dataset that is forwarded on one or more software applications. For more information on the functional requirements of a PDC see: [Phasor Data Concentrator Requirements](http://www.gridprotectionalliance.org/docs/products/openPDC/C37.244-2013.pdf)

The openPDC is much more than just a data concentrator, it is a flexible platform for processing high-speed time-series data that can adapt with changing technology to provide a future-proof phasor data architecture. The openPDC can be used to distribute data (both real-time and historical) to consuming applications and can be installed anywhere within the synchrophasor infrastructure, even on fanless computers that run in a substation environment.

Although the primary purpose of the openPDC is concentration and management of real-time streaming synchrophasors, by having its functionality based on GPA's [Time-Series Library](http://www.gridprotectionalliance.org/technology.asp#TSL) the openPDC inherits a modular design that allows it to be classified as a generic [event stream processor: ](http://en.wikipedia.org/wiki/Event_stream_processing)

![openPDC Flow Diagram](http://www.gridprotectionalliance.org/docs/products/openPDC/FlowDiagram.png)

# Features
The openPDC implements a number of standard phasor protocols which can be used to receive data from devices. The supported protocols include IEEE C37.118, IEC 61850-90-5, IEEE 1344, BPA PDCstream, F-NET, SEL Fast Message, and Macrodyne among others.

Using the [Time-Series Library](http://www.gridprotectionalliance.org/technology.asp#TSL), the openPDC can be configured to archive to any historian system, however, the system also includes an available built-in historian, the openHistorian, for data archival. The local historian comes with a visualization and extraction tool, a high-speed local API and web services, all of which can be used to extract and monitor the data being archived in real-time. The files produced by the historian can also be [analyzed using Hadoop](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Developers_Using_Hadoop.md).

With version 2.1 or later, the openPDC can be deployed in [POSIX environments](http://www.gridprotectionalliance.org/docs/products/openPDC/openPDConPOSIX.pdf) as well as on Windows.

*Other features include:*

* Lossless phasor data transformation and replication with the ability to create a configurable number of output streams
* Extensive performance statistic history such as average latency, data quality and time code errors
* Generic configuration database with support for Microsoft SQL Server and Oracle as well as free alternatives such as MySQL and SQLite
* Distributed multi-node architecture supported for high availability and throughput
* Provided output adapters for multiple historians including the [openHistorian](http://www.gridprotectionalliance.org/products.asp#Historian), [OSI-PI Historian](http://www.osisoft.com/) and [Hadoop](http://hadoop.apache.org/).
* Automated data availability reporting

See: [Getting Started with the openPDC](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Getting_Started.md).

# Documentation

Documentation for openPDC can be found [here](https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/openPDC_Documentation_Home.md).

# Deployment

* For Windows:
  1. Make sure your system meets all the requirements below.
  * Download the [latest stable release](#latest-stable-release) or [nightly build](#nightly-build).
  * Unzip.
  * Run "Setup.exe".
  * Follow the wizard.
  * Enjoy.
* For POSIX OS:
  * See [Deploying the openPDC on POSIX Platforms](http://www.gridprotectionalliance.org/docs/products/openPDC/openPDConPOSIX.pdf).

## Requirements

* .NET 4.5 or higher.
* 64-bit Windows 7 or newer or POSIX OS.
* Database management system such as:
  * SQL Server (Recommended)
  * MySQL
  * Oracle
  * PostgreSQL
  * SQLite (Not recommended for production use) - included.

## Latest Stable Release

Download the latest stable release [here](http://openpdc.codeplex.com/downloads/get/1476243) (v2.1 SP1).

Older releases are also available [here](http://openpdc.codeplex.com/releases/view/615595).

## Nightly Build

Download the nightly build [here](http://www.gridprotectionalliance.org/nightlybuilds/openHistorian/Beta/openHistorian.Installs.zip).

# Contributing
If you would like to contribute please:

1. Read the [styleguide.](https://www.gridprotectionalliance.org/docs/GPA_Coding_Guidelines_2011_03.pdf)
* Fork the repository.
* Code like a boss.
* Create a pull request.
