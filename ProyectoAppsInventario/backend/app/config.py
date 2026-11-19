from pydantic_settings import BaseSettings, SettingsConfigDict

class Settings(BaseSettings):
    database_url:str
    modo_prueba: bool=False

    model_config = SettingsConfigDict(env_file=".env")
    tenant_id: str = "621db785-00d7-4ced-b451-0f5696381174"
    api_client_id: str = "03b4dd03-4c2d-4995-b4fb-0ba2c5a94a9a"
    
    osv_url: str = "https://api.osv.dev/v1"


settings = Settings()    