import {action} from '@storybook/addon-actions';
import {linkTo} from '@storybook/addon-links';
import {storiesOf, Story, StoryDecorator} from '@storybook/react';
import {createBrowserHistory} from "history";
import * as React from 'react';
import {Provider} from "react-redux";
import {ConnectedRouter} from "react-router-redux";
import {v4} from "uuid";
import { ForceGraphLink, ForceGraphNode } from '../src/features/force-graph/domain';
import ForceGraph from "../src/features/force-graph/ForceGraph";
import configureStore from "../src/store";
const store = configureStore();

const decorator : StoryDecorator = getStory => (
    <Provider store={store}>
        {getStory()}
    </Provider>
);


storiesOf('ForceGraph', module)
.addDecorator(decorator)
.add('Empty', () => {
    const nodes: ForceGraphNode[] = [];
    const links: ForceGraphLink[] = [];
    return <ForceGraph id="a" width={window.innerWidth / 2} height={window.innerHeight / 2} nodes={nodes} links={links} />;
})
.add('Single node', () => {
    const nodes: ForceGraphNode[] = [{
        id: "a",
    }];
    const links: ForceGraphLink[] = [];
    return <ForceGraph id="a" width={window.innerWidth / 2} height={window.innerHeight / 2} nodes={nodes} links={links} />;
})
.add('Single link', () => {
    const nodes: ForceGraphNode[] = [{
        id: "a",
    },{
        id: "b",
    }];
    const links: ForceGraphLink[] = [{
        id: "0",
        source: nodes[0],
        target: nodes[1]
    }];
    return <ForceGraph id="a" width={window.innerWidth / 2} height={window.innerHeight / 2} nodes={nodes} links={links} />;
})
.add('Small graph', () => {
    const nodes: ForceGraphNode[] = [{
        id: "a",
    },{
        id: "b",
    },{
        id: "c",
    },{
        id: "d",
    },{
        id: "e",
    }];
    const links: ForceGraphLink[] = [{
        id: "0",
        source: nodes[0],
        target: nodes[1]
    }, {
        id: "1",
        source: nodes[1],
        target: nodes[4]
    }, {
        id: "2",
        source: nodes[2],
        target: nodes[3]
    }, {
        id: "3",
        source: nodes[0],
        target: nodes[4]
    }];
    return <ForceGraph id="a" width={window.innerWidth / 2} height={window.innerHeight / 2} nodes={nodes} links={links} />;
})
.add("Large Graph", () => {
    const nodes:ForceGraphNode[] = [];
    const links:ForceGraphLink[] = [];

    const numNodes = 4000;
    for(let i = 0; i < numNodes; i++){
        const node:ForceGraphNode = {
            id: v4()
        }
        nodes.push(node);
    }

    for(let i = 0; i < 200; i++)
    {
        const lhs = Math.floor(Math.random() * numNodes);
        const rhs = Math.floor(Math.random() * numNodes);
        if(lhs === rhs) {
            continue;
        }
        links.push({
            id: v4(),
            source: nodes[lhs],
            target: nodes[rhs]
        });
    }

    return <ForceGraph id="a" width={window.innerWidth / 2} height={window.innerHeight / 2} nodes={nodes} links={links} />;
});