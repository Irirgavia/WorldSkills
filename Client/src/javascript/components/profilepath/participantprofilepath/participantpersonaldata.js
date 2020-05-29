import React from 'react';
import { connect } from 'react-redux';
import PersonalData from '../personaldata/personaldata.js'

export class ParticipantPersonalData extends React.Component {
    constructor(props) {
      super(props);
    }
    
    render() {
      return <div>
        <PersonalData />
        <p>
          <label class = "questionField">Награды:</label>
          <label class = "answerField">{this.props.items.Awards}</label>
        </p>
      </div>;
        
      }
    }

    let mapProps = (state) => {
      return {
          items: state.data,
          isFetching: state.isFetching,
          isSignedIn: state.isSignedIn,
          error: state.error
      }
  }
  
  let mapDispatch = (dispatch) => {
      return {
        getPersonalData: () => dispatch(getPersonalData())
      }
  }
  
  export default connect(mapProps, mapDispatch)(ParticipantPersonalData)