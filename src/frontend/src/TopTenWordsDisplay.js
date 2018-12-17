import React from 'react'

const TopTenWordsDisplay = ({topTenWords}) => {
  return (
    <div>
      <h2 className="ui header">Top 10 Palavras</h2>

      <div className="ui inverted segment">
        <div className="ui inverted relaxed divided list">
          {topTenWords.map((w, i) => {
            return (
              <div className="item" key={i}>
                <div className="content">
                  <div className="header">{w.Word}</div>
                  {w.WordCount} vezes
                </div>
              </div>
            );
          })}
        </div>
      </div>

      <ul className="ui list">

      </ul>
    </div>
  );
}

export default TopTenWordsDisplay;