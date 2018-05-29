import {action} from '@storybook/addon-actions';
import {linkTo} from '@storybook/addon-links';
import {storiesOf, Story, StoryDecorator} from '@storybook/react';
import {createBrowserHistory} from "history";
import * as React from 'react';
import {Provider} from "react-redux";
import {ConnectedRouter} from "react-router-redux";
import ForceGraph from "../src/features/force-graph/ForceGraph";
import ForceGraphLink from "../src/features/force-graph/ForceGraphLink";
import ForceGraphNode from "../src/features/force-graph/ForceGraphNode";

import configureStore from "../src/store";

const store = configureStore();

const decorator : StoryDecorator = getStory => (
    <Provider store={store}>
        {getStory()}
    </Provider>
);

storiesOf('ForceGraph', module)
    .addDecorator(decorator)
    .add('Empty', () => <ForceGraph width={100} height={100}/>)
    .add("Single Node", () => 
        <React.Fragment>
            <ForceGraph width={100} height={100}>
                <ForceGraphNode id="b"/>
            </ForceGraph>
        </React.Fragment>
    )
    .add("Node and Link", () => 
        <ForceGraph width={100} height={100}>
            <ForceGraphNode id="a"/>
            <ForceGraphNode id="b"/>
            <ForceGraphLink/>
        </ForceGraph>
    )
