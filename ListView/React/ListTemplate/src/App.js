import './App.css';
import * as React from 'react';
import { ListViewComponent } from '@syncfusion/ej2-react-lists';
import { dataSource, LBdataSource } from './listData';
import {  MultiSelectComponent,  Inject,  CheckBoxSelection } from "@syncfusion/ej2-react-dropdowns";

export default class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      options: [],
      selectVal: []
    };
  }
  // itemTemplate(item) {
  //   return (
  //   <span className="item">
  //       <b>{item.id}</b>
  //       <i>{`:   ${item.name}`}</i>
  //   </span>
  // );
  // }
  itemTemplate(data){
    return(
    <div class="iconClass4" role="li-4" id="4444">
      <span id="list123">text4</span>
      </div>
    );
  }
  listTemplate(data) {
    return (
      <div
        className={
          data.category !== undefined
            ? "clearfix desc e-list-wrapper e-list-multi-line e-list-avatar'"
            : 'clearfix e-list-wrapper e-list-multi-line e-list-avatar'
        }
      >
        {data.imgSrc !== '' ? (
          <img className="e-avatar" src={`${data.imgSrc}`} />
        ) : (
          ''
        )}
        <span className="e-list-item-header">{data.title} </span>
        <span
          className="e-list-content e-text-overflow"
          dangerouslySetInnerHTML={{ __html: data.description }}
        />
        {data.timeStamp !== '' ? (
          <div>
            <div id="list-logo">
              <span className="bookmark" />
              <span className="comments" />
              <span className="share" />
            </div>
            <div className="timeStamp">{data.timeStamp}</div>
          </div>
        ) : (
          ''
        )}
      </div>
    );
  }

  onComplete() {
    let instance = document.getElementById('listview_template');
    instance = instance.ej2_instances[0];
    let listHeader = instance.element.childNodes[0];
    let header = listHeader.childNodes[0];
    if (header.style.display === 'none' || listHeader.childNodes.length === 3) {
      if (listHeader.childNodes[2] != null) {
        let childHeader = listHeader.childNodes[2];
        childHeader.remove();
      }
    } else {
      let headerEle = instance.element.querySelector('.e-list-header');
      let headerElement = instance.element.querySelector('#list-logo');
      let clone = headerElement.cloneNode(true);
      headerEle.appendChild(clone);
    }
    //Customizing the elements to perform our own events
    this.share = document.getElementsByClassName('share');
    this.comments = document.getElementsByClassName('comments');
    this.bookmark = document.getElementsByClassName('bookmark');
    this.timeStamp = document.getElementsByClassName('timeStamp');
    this.postActions();
  }
  // EventHnadler to Comments, BookMarks and Share Icons
  postActions() {
    for (let i = 0; i < this.comments.length; i++) {
      this.comments[i].setAttribute(
        'title',
        'We can customize this element to perform our own action'
      );
      this.comments[i].addEventListener('click', event => {
        event.stopPropagation();
      });
    }
    for (let i = 0; i < this.bookmark.length; i++) {
      this.bookmark[i].setAttribute(
        'title',
        'We can customize this element to perform our own action'
      );
      this.bookmark[i].addEventListener('click', event => {
        event.stopPropagation();
      });
    }
    for (let i = 0; i < this.share.length; i++) {
      this.share[i].setAttribute(
        'title',
        'We can customize this element to perform our own action'
      );
      this.share[i].addEventListener('click', event => {
        event.stopPropagation();
      });
    }
    for (let i = 0; i < this.timeStamp.length; i++) {
      this.timeStamp[i].addEventListener('click', event => {
        event.stopPropagation();
      });
    }
  }

  componentDidMount() {
    this.setState({
      options: [
        {id:"A", name: 'a', value: 'A'}, 
        {id:"B", name: 'b', value: 'B'}, 
        {id:"C", name: 'c', value: 'C'}
      ],
      selectVal: ["A"]
    });
  }

  render() {
    return (
      <div className="control-pane">
        <div className="control-section">
          {/* <ListViewComponent delayUpdate={true}
            id="listview_template"
            dataSource={dataSource}
            template={this.listTemplate}
            headerTitle="Syncfusion Blog"
            showHeader={true}
            showCheckBox={true}
            cssClass="e-list-template"
            actionComplete={this.onComplete.bind(this)}
            
          /> */}
        </div>
        <div>
        <MultiSelectComponent
          name={"test"}
          dataSource={this.LBdataSource}
          value={this.state.selectVal}
          mode="CheckBox"
          itemTemplate={this.itemTemplate}
        >
          <Inject services={[CheckBoxSelection]} />
        </MultiSelectComponent>
        </div>
      </div>
    );
  }
}