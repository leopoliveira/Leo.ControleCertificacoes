import axios from 'axios';

export default () =>
{
  const axiosInstance = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_DEV_URL
  })

  return axiosInstance;
}