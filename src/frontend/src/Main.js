import React from 'react'

import TopTenWordsDisplay from './TopTenWordsDisplay';
import WordsPerPostDisplay from './WordsPerPostDisplay';

const Main = ({wordsInfo}) => {
  const { TopTenWords, WordCountPerPost } = wordsInfo;

  return (
    <div>
      <h1>Resultado do Desafio</h1>

      <div class="ui horizontal segments">
        <div class="ui segment">
          <TopTenWordsDisplay topTenWords={TopTenWords} />
        </div>
        <div class="ui segment">
          <WordsPerPostDisplay wordCountPerPost={WordCountPerPost} />
        </div>
      </div>
    </div>
  );
}

export default Main;