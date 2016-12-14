[![The Open Source Phasor Data Concentrator](openPDC_Logo.png)](openPDC_Home.md "The Open Source Phasor Data Concentrator")

|   |   |   |   |   |
|---|---|---|---|---|
| **[Grid Protection Alliance](http://www.gridprotectionalliance.org "Grid Protection Alliance Home Page")** | **[openPDC Project](https://github.com/GridProtectionAlliance/openPDC "openPDC Project on GitHub")** | **[openPDC Wiki](openPDC_Home.md "openPDC Wiki Home Page")** | **[Documentation](openPDC_Documentation_Home.md "openPDC Documentation Home Page")** | **[Latest Release](https://github.com/GridProtectionAlliance/openPDC/releases "openPDC Releases Home Page")** |

# [Event stream processing](https://en.wikipedia.org/wiki/Event_stream_processing)

Copied from Wikipedia, the free encyclopedia.

Event stream processing, or ESP, is a set of technologies designed to assist the construction of event-driven information systems. ESP technologies include event visualization, event databases, event-driven middleware, and event processing languages, or complex event processing (CEP). In practice, the terms ESP and CEP are often used interchangeably. ESP deals with the task of processing streams of event data with the goal of identifying the meaningful pattern within those streams, employing techniques such as detection of relationships between multiple events, event correlation, event hierarchies, and other aspects such as causality, membership and timing.

ESP enables many different applications such as algorithmic trading in financial services, RFID event processing applications, fraud detection, process monitoring, and location-based services in telecommunications.

## Examples

By way of illustration, the following code fragments demonstrate detection of patterns within event streams. The first is an example of processing a data stream using a continuous SQL query (a query that executes forever processing arriving data based on timestamps and WINDOW duration). This code fragment illustrates a JOIN of two data streams, one for stock orders, and one for the resulting stock trades. The query outputs a stream of all Orders matched by a Trade within one second of the Order being placed. The output stream is sorted by timestamp, in this case, the timestamp from the Orders stream.

```sql
SELECT DataStream 
   Orders.TimeStamp, Orders.orderId, Orders.ticker, 
   Orders.amount, Trade.amount 
FROM Orders 
JOIN Trades OVER (RANGE INTERVAL '1' SECOND FOLLOWING)
ON Orders.orderId = Trades.orderId;
```

Another sample code fragment detects weddings among a flow of external "events" such as church bells ringing, the appearance of a man in a tuxedo or morning suit, a girl in a flowing white gown and rice flying through the air. A "complex" or "composite" event is what one infers from the individual simple events: a wedding is happening.

```sql
WHEN Person.Gender EQUALS "man" AND Person.Clothes EQUALS "tuxedo"
FOLLOWED-BY
  Person.Clothes EQUALS "gown" AND
  (Church_Bell OR Rice_Flying)
WITHIN 2 hours
ACTION Wedding
```

---

Dec 5, 2016 - Copied from [Wikipedia - Event stream processing](https://en.wikipedia.org/wiki/Event_stream_processing) by [aj](https://github.com/ajstadlin)

---

openPDC Copyright 2015 [Grid Protection Alliance](http://www.gridprotectionalliance.org)