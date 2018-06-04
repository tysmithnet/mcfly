import {action} from '@storybook/addon-actions';
import {linkTo} from '@storybook/addon-links';
import {storiesOf, Story, StoryDecorator} from '@storybook/react';
import {createBrowserHistory} from "history";
import * as React from 'react';
import {Provider} from "react-redux";
import {ConnectedRouter} from "react-router-redux";
import ForceGraph from "../src/features/force-graph/ForceGraph";

import configureStore from "../src/store";

const store = configureStore();

const decorator : StoryDecorator = getStory => (
    <Provider store={store}>
        {getStory()}
    </Provider>
);


