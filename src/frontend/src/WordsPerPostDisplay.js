import React from 'react'

const WordsPerPostDisplay = ({wordCountPerPost}) => {
  return (
    <div>
      <h2 className="ui header">Palavras por Post (sem contar palavras repetidas)</h2>

      <div className="ui inverted segment">
        <div className="ui inverted relaxed divided list">
          {wordCountPerPost.map((w, i) => {
            return (
              <div className="item" key={i}>
                <div className="content">
                  <div className="header">{w.PostTitle}</div>
                  {w.WordCount} palavras
                </div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
}

export default WordsPerPostDisplay;