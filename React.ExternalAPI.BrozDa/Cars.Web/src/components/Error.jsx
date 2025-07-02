import "../css/Error.css"

function Error({errorMsg}) {
  return (
    <div className="error-container">
      <h3>Error</h3>
      <p>{errorMsg}</p>
    </div>
  )
}

export default Error