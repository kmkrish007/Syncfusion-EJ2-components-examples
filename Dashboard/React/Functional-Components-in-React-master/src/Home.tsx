import { ButtonComponent } from "@syncfusion/ej2-react-buttons";
import { ColumnDirective, ColumnsDirective, GridComponent } from '@syncfusion/ej2-react-grids';
import { Filter, Group, Inject, Page,PageSettingsModel, Sort ,SortSettingsModel} from '@syncfusion/ej2-react-grids';

import { DashboardLayoutComponent, PanelDirective, PanelsDirective } from '@syncfusion/ej2-react-layouts';
import * as React from 'react';
import { sdata } from './datasource';

function element() {
  return(<div>value</div>)
}

function Home(){
    const pageSettings:PageSettingsModel =  { pageSize: 6 };
    const sortSettings:SortSettingsModel = { columns: [
        {field: 'EmployeeID', direction: 'Ascending' }
    ] };
    const panels : any =  [
            { "sizeX": 1, "sizeY": 1, "row": 0, "col": 0, content: '<div class="content">0</div>' },
            { "sizeX": 3, "sizeY": 2, "row": 0, "col": 1, content: '<div class="content">1</div>' },
            { "sizeX": 1, "sizeY": 3, "row": 0, "col": 4, content: '<div class="content">2</div>' },
            { "sizeX": 1, "sizeY": 1, "row": 1, "col": 0, content: '<div class="content">3</div>' },
            { "sizeX": 2, "sizeY": 1, "row": 2, "col": 0, content: '<div class="content">4</div>' },
            { "sizeX": 1, "sizeY": 1, "row": 2, "col": 2, content: '<div class="content">5</div>' },
            { "sizeX": 1, "sizeY": 1, "row": 2, "col": 3, content: '<div class="content">6</div>' }
        ];
       
    return(<div> <p>Grid-1 using Functional Components</p>
    <GridComponent dataSource={sdata} allowPaging={true} pageSettings={ pageSettings }
            allowSorting={true} sortSettings={ sortSettings }>
            <ColumnsDirective>
                <ColumnDirective field='OrderID' width='100' textAlign="Right"/>
                <ColumnDirective field='CustomerID' width='100'/>
                <ColumnDirective field='EmployeeID' width='100' textAlign="Right"/>
                <ColumnDirective field='Freight' width='100' format="C2" textAlign="Right"/>
                <ColumnDirective field='ShipCountry' width='100'/>
            </ColumnsDirective>
            <Inject services={[Page, Sort, Filter, Group]} />
        </GridComponent> 
        <p>You clicked  times</p>
        <ButtonComponent>
          Decrement
        </ButtonComponent>
        <DashboardLayoutComponent id='defaultLayout' panels={panels} columns={5}>
           <PanelsDirective>
            <PanelDirective sizeX={3} sizeY={2} row={0} col={0} content={element} header="<div>Product usage ratio</div>"/>
                        </PanelsDirective></DashboardLayoutComponent>

        </div>
)
    }

export default Home;