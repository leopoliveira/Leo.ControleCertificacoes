import type { EmployeeReadType } from "../../types/Employee/EmployeeReadType";

import API from "@/services/Api";

export async function GetAllEmployees(): Promise<EmployeeReadType[]>
{
  try
  {
    const response = await API().get("/Employee/Get");
    return response.data as EmployeeReadType[];

  } catch (error)
  {
    console.log(error);
    return [] as EmployeeReadType[];
  }
}