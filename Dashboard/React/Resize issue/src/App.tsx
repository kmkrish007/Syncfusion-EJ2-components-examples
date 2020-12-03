import { DashboardLayoutComponent,PanelDirective,  PanelsDirective,  } from "@syncfusion/ej2-react-layouts";
import * as React from 'react';


export default class App extends React.Component<{}, {}>{
    public dashboardObj: DashboardLayoutComponent;

    constructor(props: any) {
        super(props);
    }
      
    public render() {
        return (<div className="dash-container">
                <div id='edit_target' style={{ "width": "50%" }} className="control-section">
                <DashboardLayoutComponent id="defaultLayout" columns={8} allowResizing={false} allowDragging={false} ref={(scope) => { (this.dashboardObj as any) = scope; }}>
                <PanelsDirective>
                            <PanelDirective header="<div>Panel 1</div>" content="<div></div>" sizeX={2} sizeY={1} row={0} col={0} />
                            <PanelDirective header="<div>Panel 2</div>" content="<div></div>" sizeX={2} sizeY={1} row={0} col={2} />
                            <PanelDirective header="<div>Panel 3</div>" content="<div></div>" sizeX={2} sizeY={1} row={0} col={4} />
                            <PanelDirective header="<div>Panel 4</div>" content="<div></div>" sizeX={2} sizeY={1} row={0} col={6} />
                            <PanelDirective header="<div>Panel 5</div>" content="<div></div>" sizeX={6} sizeY={2} row={1} col={0} />
                            <PanelDirective header="<div>Panel 6</div>" content="<div></div>" sizeX={2} sizeY={2} row={1} col={6} />
                            <PanelDirective header="<div>Panel 7</div>" content="<div></div>" sizeX={2} sizeY={2} row={3} col={0} />
                            <PanelDirective header="<div>Panel 8</div>" content="<div></div>" sizeX={2} sizeY={2} row={3} col={2} />
                            <PanelDirective header="<div>Panel 9</div>" content="<div></div>" sizeX={2} sizeY={2} row={3} col={4} />
                            <PanelDirective header="<div>Panel 10</div>" content="<div></div>" sizeX={2} sizeY={2} row={3} col={6} />
                        </PanelsDirective>
                </DashboardLayoutComponent>
                </div>
            </div>);
    }
   
    
};