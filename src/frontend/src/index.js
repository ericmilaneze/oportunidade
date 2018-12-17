import React from 'react'
import ReactDOM from 'react-dom'

import Main from './Main';
import Spinner from './Spinner';

class App extends React.Component {
  state = { wordsInfo: null, errorMessage: '' };

  componentDidMount() {
    fetch('http://localhost/MinutoSeguros.Opt.WebAPI/api/FeedInformation')
      .then(response => {
        response.json().then((d) => {
          this.setState({ wordsInfo: d.data });
        });
      })
      .catch(reason => {
        this.setState({ errorMessage: 'Ocorreu um erro ao recuperar os dados.' });
        console.error(reason);
      });
  }

  renderContent() {
    if (this.state.errorMessage && !this.state.wordsInfo) {
      return (
        <div>{this.state.errorMessage}</div>
      );
    }

    if (this.state.wordsInfo) {
      return <Main wordsInfo={this.state.wordsInfo} />
    }

    return <Spinner />
  }

  render() {
    return <div>{this.renderContent()}</div>
  }
}

ReactDOM.render(<App />, document.getElementById('root'));