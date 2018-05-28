import { action } from '@storybook/addon-actions';
import { linkTo } from '@storybook/addon-links';
import { storiesOf, Story, StoryDecorator } from '@storybook/react';
import { createBrowserHistory } from "history";
import * as React from 'react';
import {Provider} from "react-redux";
import { ConnectedRouter } from "react-router-redux";
import ForceGraph from "../src/components/ForceGraph";
import ForceGraphLink from "../src/components/ForceGraphLink";
import ForceGraphNode from "../src/components/ForceGraphNode";
import {configureStore, RootState} from "../src/renameme";

const history = createBrowserHistory({});
const store = configureStore(history);

const decorator :StoryDecorator = getStory => (
    <Provider store={store}>
        {getStory()}
    </Provider>);

storiesOf('ForceGraph', module)
    .addDecorator(decorator)
    .add('Empty', () => <ForceGraph width={100} height={100}/>)
    .add("Single Node", () => 
        <ForceGraph width={100} height={100}>
            <ForceGraphNode id="b" />
        </ForceGraph>
        )
    .add("Node and Link", () => 
    <ForceGraph width={100} height={100}>
        <ForceGraphNode id="b" />
        <ForceGraphLink x1={0} y1={0} x2={10} y2={10} />
    </ForceGraph>
    )
