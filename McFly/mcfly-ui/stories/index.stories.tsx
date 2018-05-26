import * as React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';
import { linkTo } from '@storybook/addon-links';
import ForceGraph from "../src/components/ForceGraph";
import ForceGraphNode from "../src/components/ForceGraphNode";
import ForceGraphLink from "../src/components/ForceGraphLink";

storiesOf('ForceGraph', module)
    .add('Empty', () => <ForceGraph />)
    .add("Single Node", () => 
        <ForceGraph>
            <ForceGraphNode />
        </ForceGraph>
        )
    .add("Node and Link", () => 
    <ForceGraph>
        <ForceGraphNode />
        <ForceGraphLink />
    </ForceGraph>
    )
