import React from "react";

export default class NoResults extends React.Component {
  render() {
    return <div id="noresults">{this.props.mes}</div>;
  }
}
