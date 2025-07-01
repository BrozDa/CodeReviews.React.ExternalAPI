const API_URL = "https://localhost:7167"

export const getCars = async () => {
  const response = await fetch(`${API_URL}/api/cars`);
  if (!response.ok) throw new Error('Failed to fetch cars');
  const data = await response.json();
  return data;
}

export const getCarByID = async (id) => {
  const response = await fetch(`${API_URL}/api/cars/${id}`);
  if (!response.ok) throw new Error('Failed to fetch car details');
  const data = await response.json();
  return data;
}