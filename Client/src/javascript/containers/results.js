import React from "react";
import { connect } from "react-redux";
import {
  getResultsByYear,
  getSkills,
  getStages,
  getResultsCSV,
} from "../actions/actions.js";
import Error from "../components/system/error.js";
import Loading from "../components/system/loading.js";
import ResultsFirstLaunch from "../components/results/resultsfirstlaunch.js";
import ResultsView from "../components/results/resultsview.js";

export class Results extends React.Component {
  constructor(props) {
    super(props);
    this.searchResults = this.searchResults.bind(this);
    this.downloadResults = this.downloadResults.bind(this);
    this.state = {
      firstLaunchFlag: true,
      skill: "",
      stage: "",
      year: "",
    };
  }

  componentDidMount() {
    this.props.getSkills();
    this.props.getStages();
  }

  searchResults(skill, stage, year) {
    this.setState({
      skill: skill,
      stage: stage,
      year: year,
      firstLaunchFlag: false,
    });
    this.props.getResultsByYear(skill, stage, year);
  }

  downloadResults(skill, stage, year) {
    this.props.getResultsCSV(skill, stage, year);
  }

  render() {
    console.log(this.props.isFetching);
    if (this.props.error) {
      console.log("ResultsError");
      return <Error error={this.props.error.message} />;
    } else if (
      this.props.isFetching ||
      this.props.skillNames.length == 0 ||
      this.props.stageTypes.length == 0
    ) {
      return <Loading />;
    } else if (this.state.firstLaunchFlag) {
      console.log("ResultsFirstLaunch");
      return (
        <ResultsFirstLaunch
          searchResults={this.searchResults}
          skillNames={this.props.skillNames}
          stageTypes={this.props.stageTypes}
        />
      );
    } else {
      console.log("ResultsView");
      return (
        <ResultsView
          searchResults={this.searchResults}
          skillNames={this.props.skillNames}
          stageTypes={this.props.stageTypes}
          downloadResults={this.downloadResults}
          skill={this.state.skill}
          stage={this.state.stage}
          year={this.state.year}
          results={this.props.items}
        />
      );
    }
  }
}

let mapProps = (state) => {
  return {
    items: state.data,
    isFetching: state.isFetching,
    error: state.error,
    stageTypes: state.stageTypes,
    skillNames: state.skillNames,
  };
};

let mapDispatch = (dispatch) => {
  return {
    getResultsByYear: (skill, stage, year) =>
      dispatch(getResultsByYear(skill, stage, year)),
    getSkills: () => dispatch(getSkills()),
    getStages: () => dispatch(getStages()),
    getResultsCSV: (skill, stage, year) =>
      dispatch(getResultsCSV(skill, stage, year)),
  };
};

export default connect(mapProps, mapDispatch)(Results);
