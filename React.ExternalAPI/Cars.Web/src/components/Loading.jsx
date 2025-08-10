import React from 'react'
import "../css/Loading.css"
function Loading() {
  return (
    <div className="loading-container">
      <p>Loading</p>
      <img src="/loading.svg" alt="loading icon"/>
    </div>
  )
}

export default Loading