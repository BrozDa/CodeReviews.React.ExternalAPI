import React from 'react'
import "../css/CarDetail.css"
import { useNavigate } from "react-router-dom";

function CarDetail({carId, carName,carImg, carDescription}) {

  const navigate = useNavigate();
  const handleClick = () => {
    navigate("/");
  };

  return (
    <>
    <div className="car-detail-card">
      <div className="car-detail-name">
        <p>{carName}</p>
      </div>
      <div className="car-detail-image">
        <img src={carImg} alt={`Image of ${carName} car`} />
      </div>
      <div className="car-detail-description">
        <p>{carDescription}</p>
      </div>
      <div className="homepage-btn-container">
        <button onClick={handleClick}>
          Go Home
        </button>
      </div>
    </div>
    
    </>
  );
}

export default CarDetail