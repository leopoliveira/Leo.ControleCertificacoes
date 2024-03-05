import type { EmployeeReadType } from "../../types/Employee/EmployeeReadType";

import axios from "axios";

axios.defaults.baseURL = import.meta.env.VITE_API_BASE_DEV_URL;

export async function GetAllEmployees(): Promise<EmployeeReadType[]>
{
  try
  {
    const response = await axios.get("/Employee/Get");
    return response.data as EmployeeReadType[];

  } catch (error)
  {
    console.log(error);
    return [] as EmployeeReadType[];
  }
}