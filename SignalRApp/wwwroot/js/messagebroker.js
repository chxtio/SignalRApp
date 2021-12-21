"use strict";

// Get reference to signalR hub
const signalRConnection = new signalR.HubConnectionBuilder()
    .withUrl("/messagebroker")
    .configureLogging(signalR.LogLevel.Information)
    .build();

signalRConnection.start().then(function () {
    console.log("SignalR Hub Connected!");
}).catch(function (err) {
    return console.error(err.toString());
});

let msgCount = 0;

// Subscribe to method/event
signalRConnection.on("onMessagedReceived", function (eventMessage) {
    msgCount++;
    const msgCountH4 = document.getElementById("messageCount");
    msgCountH4.innerText = "Messages: " + msgCount.toString();
    const ul = document.getElementById("messages");
    const li = document.createElement("li");
    li.innerText = msgCount.toString();

    for (const prop in eventMessage) {
        const newDiv = document.createElement("div");
        const classAttrib = document.createAttribute("style");
        classAttrib.value = "font-size: 80%";
        newDiv.setAttributeNode(classAttrib);
        const newContent = document.createTextNode(`${prop}: ${eventMessage[prop]}`);
        newDiv.appendChild(newContent);
        li.appendChild(newDiv);
    }

    ul.appendChild(li);
    window.scrollTo(0, document.body.scrollHeight);
    console.log(eventMessage);
});