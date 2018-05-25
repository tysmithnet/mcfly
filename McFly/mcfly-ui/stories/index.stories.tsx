import * as React from 'react';

import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';
import { linkTo } from '@storybook/addon-links';
import ForceGraph from "../src/components/ForceGraph";

storiesOf('ForceGraph', module)
    .add('Empty', () => <ForceGraph />);
