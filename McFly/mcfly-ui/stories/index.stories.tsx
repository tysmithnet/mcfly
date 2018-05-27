import * as React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';
import { linkTo } from '@storybook/addon-links';
import ForceGraph from "../src/components/ForceGraph";
import ForceGraphNode from "../src/components/ForceGraphNode";
import ForceGraphLink from "../src/components/ForceGraphLink";

storiesOf('ForceGraph', module)
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
