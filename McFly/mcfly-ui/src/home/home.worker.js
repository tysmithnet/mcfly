onmessage = (message) => {
    console.log(`Worker: ${message.data}`);
    if (message.data === "ping") {
        postMessage("pong");
    }
}