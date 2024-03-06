import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import axios from "axios";

axios.defaults.baseURL = import.meta.env.VITE_API_BASE_DEV_URL;

export async function GetByCode(code: string): Promise<CertifiedReadType[]>
{
  try
  {
    const response = await axios.get(`/certified/getByCode/${ code }`);

    if (response.status !== 200)
    {
      return [] as CertifiedReadType[];
    }

    return response.data as CertifiedReadType[];
  } catch (error)
  {
    console.error(error);
    return [] as CertifiedReadType[];
  }
}