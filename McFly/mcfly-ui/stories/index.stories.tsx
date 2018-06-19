import {storiesOf, Story, StoryDecorator} from "@storybook/react";
import * as React from "react";
import {AddLinks, AddLinksProvider, AddNodes, AddNodesProvider, Empty, ExtraLargeGraph, LargeGraph, MediumGraph, SingleNode, SmallGraph} from "../src/features/force-graph/stories";

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

storiesOf("ForceGraph/Dynamic", module)
    .addDecorator(story => <AddLinksProvider story={story()} />)
    .add("Add Links", () => {
        return <AddLinks />;
    });