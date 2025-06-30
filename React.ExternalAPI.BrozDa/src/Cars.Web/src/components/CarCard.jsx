import "../css/CarCard.css"

function CarCard({carName, imgUrl}) {
  return (
    <div className='car-card'>
      <div className='car-name'>
        <p>{carName}</p>
      </div>
      <div className='car-image' >
        <img src={imgUrl} alt={`Image of ${carName} car`}/>
      </div>
    </div>
  )
}

export default CarCard