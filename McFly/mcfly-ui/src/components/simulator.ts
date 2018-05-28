// tslint:disable-next-line:no-console
console.log('hello from a webworker');

addEventListener('message', (message) => {
    // tslint:disable-next-line:no-console
    console.log('in webworker', message);
    postMessage('this is the response ' + message.data, "me");
});