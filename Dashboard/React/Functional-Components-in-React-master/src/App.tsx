import { ButtonComponent } from "@syncfusion/ej2-react-buttons";
import { DashboardLayoutComponent,PanelDirective,  PanelsDirective,  } from "@syncfusion/ej2-react-layouts";

import * as React from 'react';


export default class App extends React.Component<{}, {}>{
    public dashboardObj: DashboardLayoutComponent;
    public btnClick(): void {
        const dashboard: any =  (document.getElementById("edit_dashboard") as any).ej2_instances[0];
        // change parent container width
        (document.getElementById("edit_target") as any).style.width = "25%";
        // call the refresh method

        dashboard.refresh();
      }

  
    public render() {
        return  (<div>
            <div id='edit_target' style ={{"width": "1200px"}} className="control-section">
            <div>
                    <div style={{ "width": "100%", "height": "30px" }}>
                        <ButtonComponent cssClass='e-outline e-flat e-primary'  iconCss='edit' isToggle={true} onClick={this.btnClick} style={{ "float": "right", "width": "75px" }}>
                            Edit
                        </ButtonComponent>
                    </div>
                </div>
           <DashboardLayoutComponent id="edit_dashboard" columns={6} ref={(scope ) => { (this.dashboardObj as any) = scope; } }  >
                <PanelsDirective>
                            <PanelDirective header="<div>Panel 1</div>" content="<div></div>" sizeX={2} sizeY={2} row={0} col={0}/>
                            <PanelDirective header="<div>Panel 2</div>" content="<div></div>" sizeX={2} sizeY={2} row={0} col={2}/>
                            <PanelDirective header="<div>Panel 3</div>" content="<div></div>" sizeX={2} sizeY={2} row={0} col={4}/>
                            <PanelDirective header="<div>Panel 4</div>" content="<div></div>" sizeX={4} sizeY={2} row={2} col={0}/>
                            <PanelDirective header="<div>Panel 5</div>" content="<div></div>" sizeX={2} sizeY={2} row={2} col={4}/>
                        </PanelsDirective>
                </DashboardLayoutComponent>
            </div>
          </div>
        );
        
    }
   
    
};