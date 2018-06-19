import {storiesOf, Story, StoryDecorator} from "@storybook/react";
import * as React from "react";
import {AddRemoveGraphElements, AddRemoveGraphElementsProvider, Empty, ExtraLargeGraph, LargeGraph, MediumGraph, SingleNode, SmallGraph} from "../src/features/force-graph/stories";

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
    .addDecorator(story => <AddRemoveGraphElementsProvider story={story()} />)
    .add("Add or Remove Graph Elements", () => {
        return <AddRemoveGraphElements />;
    });
