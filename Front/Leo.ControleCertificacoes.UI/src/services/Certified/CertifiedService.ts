import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import axios from "axios";

axios.defaults.baseURL = import.meta.env.VITE_API_BASE_DEV_URL;

export async function GetByCode(code: string): Promise<CertifiedReadType[]>
{
  try
  {
    const response = await axios.get(`/Employee/${ code }/Certifieds`);
    return response.data as CertifiedReadType[];

  } catch (error)
  {
    console.error(error);
    return [] as CertifiedReadType[];
  }
}