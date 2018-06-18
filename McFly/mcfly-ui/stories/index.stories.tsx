import {action} from "@storybook/addon-actions";
import {linkTo} from "@storybook/addon-links";
import {storiesOf, Story, StoryDecorator} from "@storybook/react";
import {createBrowserHistory} from "history";
import * as React from "react";
import {Provider} from "react-redux";
import {ConnectedRouter} from "react-router-redux";
import {v4} from "uuid";
import { ForceGraphLink, ForceGraphNode } from "../src/features/force-graph/domain";
import ForceGraph from "../src/features/force-graph/ForceGraph";
import {AddNodes, AddNodesProvider, Empty, ExtraLargeGraph, LargeGraph, MediumGraph, SingleNode, SmallGraph} from "../src/features/force-graph/stories";
import configureStore from "../src/store";

storiesOf("ForceGraph/Static", module)
    .add("Empty", () => {
        return <Empty />;
    })
    .add("Single Node", () => {
      return <SingleNode />;  
    })
    .add("Small Graph", () => {
        return <SmallGraph />;
    }).add("Medium Graph", () => {
        return <MediumGraph />;
    }).add("Large Graph", () => {
        return <LargeGraph />;
    })
    .add("Extra Large Graph", () => {
        return <ExtraLargeGraph />;
    });

storiesOf("ForceGraph/Dynamic", module)
    .addDecorator(story => <AddNodesProvider story={story()} />)
    .add("Add Nodes", () => {
        return <AddNodes />;
    });